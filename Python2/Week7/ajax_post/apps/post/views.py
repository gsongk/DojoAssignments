# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import Post
from django.shortcuts import render, HttpResponse
from django.core import serializers
import json


def index(request):
    return render(request, 'post/index.html')

def init(request):
    return all_posts_json()

def all_posts_json():
    return HttpResponse(serializers.serialize("json", Post.objects.all()),
                        content_type='application/json')

def create(request):
    Post.objects.create(content=request.POST['content'])
    return all_posts_json()
