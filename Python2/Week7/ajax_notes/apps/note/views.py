# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.core import serializers
from django.shortcuts import render, HttpResponse
from .models import Note
import json

# Create your views here.
def index(request):
    return render(request, 'note/index.html')

def init(request):
    return all_notes_json()

def create(request):
    Note.objects.create(content=request.POST['content'], title=request.POST['title'])
    return all_notes_json()

def update(request, note_id):
    print request.POST
    note_to_update = Note.objects.get(id=note_id)
    note_to_update.content = request.POST['content']
    note_to_update.save()
    return all_notes_json()

def destroy(request, note_id):
    note_to_delete = Note.objects.get(id=note_id)
    note_to_delete.delete()
    return all_notes_json()

def all_notes_json():
    return HttpResponse(serializers.serialize("json", Note.objects.all()), content_type="application/json")