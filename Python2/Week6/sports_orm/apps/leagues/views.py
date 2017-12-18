from django.shortcuts import render, redirect
from .models import League, Team, Player

from . import team_maker

def index(request):
	context = {
		# Leagues
		"leagues": League.objects.all(),
		"teams": Team.objects.all(),
		"players": Player.objects.all(),
		"baseball" : League.objects.filter(sport__contains="baseball"),
		"women_league" : League.objects.filter(name__contains="Women"),
		"hockey_league" : League.objects.filter(sport__contains="hockey"),
		"no_football_league" : League.objects.exclude(sport__contains="football"),
		"conference_league" : League.objects.filter(name__contains="conference"),

		# Teams
		"atlanta_region1" : Team.objects.filter(location__contains="toronto"),
		"atlanta_region2" : Team.objects.filter(location__contains="montreal"),
		"atlanta_region3": Team.objects.filter(location__contains="ontario"),

		"dallas_location" : Team.objects.filter(location__contains="dallas"),
		"raptors_name" : Team.objects.filter(team_name__contains="raptors"),
		"city_name" : Team.objects.filter(location__contains="city"),
		"t_name" : Team.objects.filter(team_name__startswith="t"),
		"alphabet_location" : Team.objects.order_by("location"),
		"team_name_reversed" : Team.objects.order_by("-team_name"),

		# player
		"cooper_last_name" : Player.objects.filter(last_name__contains="cooper"),
		"joshua_first_name" : Player.objects.filter(first_name__contains="joshua"),
		"cooper_last_name_no_joshua": Player.objects.filter(last_name__contains="cooper").exclude(first_name__contains="joshua"),
		
		"alexander_or_wyatt1" : Player.objects.filter(first_name__contains="alex"),
		"alexander_or_wyatt2": Player.objects.filter(first_name__contains="wyatt")
	}
	return render(request, "leagues/index.html", context)

def make_data(request):
	team_maker.gen_leagues(10)
	team_maker.gen_teams(50)
	team_maker.gen_players(200)

	return redirect("index")
