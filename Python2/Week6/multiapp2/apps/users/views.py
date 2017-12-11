# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render

# Create your views here.
def register(request):
    return HttpResponse('placeholder for users to create a new user record')

def login (request):
    return HttpResponse ('placebholder to later display all the list of users')

def new (request):
    return redirect('/register')

def index(request):
    return HttpResponse('placeholdre to later display all the list of users')