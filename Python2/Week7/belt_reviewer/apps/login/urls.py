from django.conf.urls import url
from . import views           # This line is new!

urlpatterns = [
  url(r'^$', views.index),     # This line has changed!
  url(r'^register$', views.register),
  url(r'^login$', views.login, name='do_the_login'),
  url(r'^logout$', views.logout, name='logout'),
  url(r'^user/(?P<user_id>\d+)$', views.show),
  url(r'^admin$', views.admin),
]
