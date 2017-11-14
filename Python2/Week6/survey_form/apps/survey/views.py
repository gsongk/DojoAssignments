# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    return render(request, 'survey/index.html')

def result(request):
    return render(request, 'survey/result.html')

def create(request):
    try:
        request.session['tries']
    except KeyError:
        request.session['tries'] = 0
    request.session['name'] = request.POST['name']
    request.session['location'] = request.POST['location']
    request.session['language'] = request.POST['language']
    request.session['comment'] = request.POST['comment']
    request.session['tries'] += 1
    return redirect('/result')
