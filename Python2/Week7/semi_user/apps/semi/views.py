# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import User
from django.contrib.messages import error
from django.shortcuts import render, HttpResponse, redirect

# Create your views here.

# Index
def index(request):
    context = {
        'users': User.objects.all()
    }
    return render(request, 'users/index.html', context)

# Actual New html page
def new(request):
    return render(request, "users/new.html")

# Action behind new page
def create(request):
    errors = User.objects.validate(request.POST)
    if len(errors):
        for field, message in errors.iteritems():
            error(request, message, extra_tags=field)

        return redirect('/users/new')

    User.objects.create(
        first_name=request.POST['first_name'],
        last_name=request.POST['last_name'],
        email=request.POST['email'],
    )
    return redirect('/users')

# The actual edit page
def edit(request, user_id):
    context = {
        'user': User.objects.get(id=user_id)
    }
    return render(request, 'users/edit.html', context)

# Action behind Edit
def update(request, user_id):
    errors = User.objects.validate(request.POST)
    if len(errors):
        for field, message in errors.iteritems():
            error(request, message, extra_tags=field)

        return redirect('/users/{}/edit'.format(user_id))

    user_to_update = User.objects.get(id=user_id)
    user_to_update.first_name = request.POST['first_name']
    user_to_update.last_name = request.POST['last_name']
    user_to_update.email = request.POST['email']
    user_to_update.save()
    return redirect('/users')

# Page that shows individual users
def show(request, user_id):
    context = {
        'user': User.objects.get(id=user_id)
    }
    return render(request, 'users/show.html', context)

# Deletes the user
def destroy(request, user_id):
    User.objects.get(id=user_id).delete()
    return redirect('/users')
