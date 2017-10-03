# You're going to create a mini-game that helps a ninja make some money! 
# When you start the game, your ninja should have 0 gold. 
# The ninja can go to different places (farm, cave, house, casino) 
# and earn different amounts of gold. In the case of a casino, your 
# ninja can earn or LOSE up to 50 golds. Your job is to create a web app 
# that allows this ninja to earn gold and to display past activities of this ninja.

from flask import Flask, render_template, request, redirect, session
import random
import time

app = Flask(__name__)

app.secret_key = 'ThisIsSecret'

@app.route('/')
def index():

    if 'your_gold' not in session:
        session['your_gold'] = 0
        session['activities'] = []
        print session
    return render_template('index.html')

@app.route('/process_money')
def reset():
    session.clear()
    return redirect('/')

@app.route('/process_money', methods=['POST'])
def process_money():
    
    if request.form['building'] == 'farm':
        amount = random.randint(10,21)
        session['your_gold'] += amount
        session['activities'].append('You earned '+str(amount)+' gold from the farm. ('+str(time.strftime('%A %B, %d %Y %H:%M'))+')')
    
    elif request.form['building'] == 'cave':
        amount = random.randint(5,11)
        session['your_gold'] += amount
        session['activities'].append('You earned '+str(amount)+' gold from the cave. ('+str(time.strftime('%A %B, %d %Y %H:%M'))+')')
    
    elif request.form['building'] == 'house':
        amount = random.randint(2,6)
        session['your_gold'] += amount
        session['activities'].append('You earned '+str(amount)+' gold from the house. ('+str(time.strftime('%A %B, %d %Y %H:%M'))+')')
    
    elif request.form['building'] == 'casino':
        amount = random.randint(-50, 51)
        session['your_gold'] += amount

        if amount<0:
            session['activities'].append('You lost '+str(amount)+' gold from the casino. ('+str(time.strftime('%A %B, %d %Y %H:%M'))+')')
        
        elif amount>0:
            session['activities'].append('You gained '+str(amount)+' gold from the casino. ('+str(time.strftime('%A %B, %d %Y %H:%M'))+')')
        
        else:
            session['activities'].append('You earned '+str(amount)+' gold from the casino. ('+str(time.strftime('%A %B, %d %Y %H:%M'))+')')
    
    session['your_gold'] += amount
    return redirect('/')

app.run(debug=True)