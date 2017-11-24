# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from time import gmtime, strftime

# Create your views here.

def index(response):
    print 'Hi'
    context={
    "time": strftime(" %Y-%m-%d %H:%M %S %p", gmtime())
    }
    return render(response, 'main/index.html', context)
