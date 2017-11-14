from __future__ import unicode_literals
from datetime import datetime
from django.shortcuts import render

def index(request):
    context = {
        "time": datetime.now()
    }
    return render(request, "time_display/index.html", context)