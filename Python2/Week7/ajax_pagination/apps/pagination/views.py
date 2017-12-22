# -*- coding: utf-8 -*-
from __future__ import unicode_literals
#from http_test import get_leads
from django.shortcuts import render, HttpResponse
from .models import Lead
from django.core import serializers
from django.core.paginator import Paginator
from django.db.models import Q
import json

LEADS_PER_PAGE = 20

# Create your views here.


def fetch_leads(request, filt=None):
    return json_leads(filt)


def index(request):
    return render(request, 'pagination/index.html')


def filt(request):
    return json_leads(filt=request.POST)


def json_leads(filt=None):
    leads = Lead.objects.all()
    if filt != None:
        if filt["name"] != "":
            leads = leads.filter(Q(first_name__contains=filt["name"]) | Q(
                last_name__contains=filt["name"]))
        if filt["to"] != "":
            leads = leads.filter(registered_datetime__lt=filt["to"])
        if filt["from"] != "":
            leads = leads.filter(registered_datetime__gt=filt["from"])
    else:
        filt = {"page": 1}

    p = Paginator(leads, LEADS_PER_PAGE)
    serialized = {
        "object_list": serializers.serialize("json", p.page(int(filt["page"])).object_list),
        "pages": range(p.num_pages)
    }
    return HttpResponse(json.dumps(serialized),
                        content_type="application/json")
