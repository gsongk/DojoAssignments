from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^initialize$', views.init),
    url(r'^create_note$', views.create),
    url(r'^update/(?P<note_id>\d+)$', views.update),
    url(r'^delete/(?P<note_id>\d+)$', views.destroy),
]
