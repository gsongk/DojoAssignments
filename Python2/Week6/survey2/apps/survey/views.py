# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    return render(request, 'survey/index.html')

def result(request):
    return render(request, 'survey/result.html')

def process(request):
    try:
        request.session['count']
    except KeyError:
        request.session['count'] = 0
    request.session['name'] = request.POST['name']
    request.session['location'] = request.POST['location']
    request.session['language'] = request.POST['language']
    request.session['comment'] = request.POST['comment']
    request.session['count'] += 1
    return redirect('/result')

