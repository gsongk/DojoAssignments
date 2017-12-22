from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^fetch$', views.fetch_leads),
    url(r'^fetch/(?P<page_num>\d+)$', views.fetch_leads),
    url(r'^filter$', views.filt),
    url(r'^(?P<page_num>\d+)$', views.index)
]
