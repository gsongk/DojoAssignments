# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, redirect
import random
from datetime import datetime

# Create your views here.
def index(request):
    try:
        request.session['total_gold']
    except KeyError:
        request.session['total_gold'] = 0
    return render(request, 'ninja/index.html')

def process(request, building):
    gold = 0
    timestamp = datetime.now()
    action = 'EARNED '
    if building =='farm':
        gold = random.randrange(10, 21)
    elif building =='cave':
        gold = random.randrange(5, 11)
    elif building =='house':
        gold = random.randrange(2, 6)
    else:
        gold = random.randrange(-50, 51)
        if gold < 0:
            action = 'LOST '
    log = {
        'class' : action,
        'message': "You {} {} golds from the {} ({})".format(action, abs(gold), building, timestamp)
    }
    try:
        log_list = request.session['logs']
    except KeyError:
        log_list = []
    
    request.session['total_gold'] += gold

    log_list.append(log)
    request.session['logs'] = log_list

    if request.session['total_gold'] <= 0:
        del request.session['total_gold']
        log = {
            'message' : "You Lost! Please play again!"
        }
        log_list.append(log)
        request.session['logs'] = log_list
    return redirect('/')
