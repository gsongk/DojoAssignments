# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from .models import Review, Author, Book
from django.shortcuts import render, redirect
from django.contrib import messages

# Create your views here.
def index(request):
    context = {
        'recent': Review.objects.recent_and_not()[0],
        'more': Review.objects.recent_and_not()[1]
    }
    return render(request, 'books/index.html', context)

def add(request):
    context = {
        "authors": Author.objects.all()
    }
    return render(request, 'books/add.html', context)

def show(request, book_id):
    context = {
        'book': Book.objects.get(id=book_id)
    }
    return render(request, 'books/show.html', context)

def create(request):
    errs = Review.objects.validate_review(request.POST)
    if errs:
        for e in errs:
            messages.error(request, e)
    else:
        book_id = Review.objects.create_review(request.POST, request.session['user_id']).book.id
    return redirect('/books/{}'.format(book_id))

def create_additional(request, book_id):
    the_book = Book.objects.get(id=book_id)
    new_book_data = {
        'title': the_book.title,
        'author': the_book.author.id,
        'rating': request.POST['rating'],
        'review': request.POST['review'],
        'new_author': ''
    }
    errs = Review.objects.validate_review(new_book_data)
    if errs:
        for e in errs:
            messages.error(request, e)
    else:
        Review.objects.create_review(new_book_data, request.session['user_id'])
    return redirect('/books/' + book_id)