# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    response= "Hello, I am your first request!"
    return HttpResponse (response)

def new(request):
    response = "New Creation"
    return HttpResponse (response)

def create (request):
    return redirect('/')

def show (request, num):
    response = "Blog Number: {}".format(num)
    return HttpResponse(response)

def edit (request, num):
    response = "Edit Number: {}".format(num)
    return HttpResponse (response)

def delete (request, num):
    return redirect ('/')
