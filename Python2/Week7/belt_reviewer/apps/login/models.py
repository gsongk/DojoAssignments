# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models
import re
import bcrypt

# Create your models here.
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
NAME_REGEX = re.compile(r'^[A-Za-z ]+[A-Za-z]\w+$')

class UserManager(models.Manager):
    def validate_login(self, post_data):
        errors = []
        # check DB for post_data['email']
        if len(self.filter(email=post_data['email'])) > 0:
            # check this user's password
            user = self.filter(email=post_data['email'])[0]
            if not bcrypt.checkpw(post_data['password'].encode(), user.password.encode()):
                errors.append('password incorrect')
        else:
            errors.append('email incorrect')

        if errors:
            return errors
        return user

    def validate_registration(self, post_data):
        errors = []
        # check length of name fields
        if len(post_data['full_name']) < 2 or len(post_data['alias']) < 2:
            errors.append("name fields must be at least 3 characters")
        # check length of name password
        if len(post_data['password']) < 8:
            errors.append("password must be at least 8 characters")
        # check name fields for letter characters
        if not re.match(NAME_REGEX, post_data['full_name']) or not re.match(NAME_REGEX, post_data['alias']):
            errors.append('name fields must be letter characters only')
        # check emailness of email
        if not re.match(EMAIL_REGEX, post_data['email']):
            errors.append("invalid email")
        # check uniqueness of email
        if len(User.objects.filter(email=post_data['email'])) > 0:
            errors.append("email already in use")
        # check password == password_confirm
        if post_data['password'] != post_data['password2']:
            errors.append("passwords do not match")

        if not errors:
            # make our new user
            # hash password
            hashed = bcrypt.hashpw(
                (post_data['password'].encode()), bcrypt.gensalt(5))

            new_user = self.create(
                full_name=post_data['full_name'],
                alias=post_data['alias'],
                email=post_data['email'],
                password=hashed
            )
            return new_user
        return errors

class User(models.Model):
    full_name = models.CharField(max_length=255)
    alias = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = UserManager()

    def __str__(self):
        return self.email
