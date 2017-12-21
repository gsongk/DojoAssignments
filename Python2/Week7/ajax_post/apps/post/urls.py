from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^initialize', views.init),
    url(r'^create$', views.create)
]
