# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, redirect
from django.contrib import messages
from .models import User
from .models import Review

# Create your views here.
# Main Page
def index(request):
    return render(request, 'books/index.html')

# Action that occurs when person registers

def register(request):
    result = User.objects.validate_registration(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/')
    request.session['user_id'] = result.id
    messages.success(request, "Successfully registered!")
    return redirect('/')

# Action that occurs when they login


def login(request):
    result = User.objects.validate_login(request.POST)
    if type(result) == list:
        for err in result:
            messages.error(request, err)
        return redirect('/')
    request.session['user_id'] = result.id
    messages.success(request, "Successfully logged in!")
    return redirect('/success')


# Main page for the reviews
def success(request):
    context = {
        "books": Review.objects.all(),
        "users": User.objects.all()
        }
    return render(request, 'books/main.html', context)
