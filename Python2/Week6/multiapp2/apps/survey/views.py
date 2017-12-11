# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    return HttpResponse("Placeholder to display all the surveys created")

def new(request):
    return HttpResponse("Placeholder for users to add a new survey")