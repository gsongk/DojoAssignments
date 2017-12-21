# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, redirect, HttpResponseRedirect, reverse
from django.contrib import messages
from .models import User

def index(request):
    return render(request, 'login/index.html')

def register(request):
    result = User.objects.validate_registration(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/')
    request.session['user_id'] = result.id
    messages.success(request, "Successfully registered!")
    return redirect('/')

def login(request):
    result = User.objects.validate_login(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/')
    request.session['user_id'] = result.id
    messages.success(request, "Successfully logged in!")
    return HttpResponseRedirect(reverse("review:index"))

def logout(request):
    for key in request.session.keys():
        del request.session[key]
    return redirect('/')

def show(request, user_id):
    user = User.objects.get(id=user_id)
    unique_ids = user.reviews_left.all().values("book").distinct()
    unique_books = []
    for book in unique_ids:
        unique_books.append(Book.objects.get(id=book['book']))
    context = {
        'user': user,
        'unique_book_reviews': unique_books
    }
    return render(request, 'login/show.html', context)

def admin(request):
    context = {
        'User' : User.objects.all
    }
    return render(request, 'login/admin.html', context)
