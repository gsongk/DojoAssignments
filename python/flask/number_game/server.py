#Assignment: Great Number Game
#Create a site that when a user loads it creates a random number between 
#1-100 and stores the number in session. Allow the user to guess at the 
#number and tell them when they are too high or too low. If they guess the 
#correct number tell them and offer to play again.

#In order to generate a random number you can use the "random" python module:
from flask import Flask, render_template, request, redirect, session, flash, get_flashed_messages

app = Flask(__name__)

app.secret_key = 'ThisIsSecret'

@app.route('/')

def index():
    # if rand number not already assigned to session, then assign rand number
    if "guesses" not in session:
        import random
        session['guesses'] = random.randrange(0, 101)
    return render_template('index.html', messages=get_flashed_messages())

@app.route('/reset')
def clear():
    session.clear()
    return redirect('/')

@app.route('/guesses', methods=['POST'])
def guesses():
    
    guess = int(request.form['guess'])
    
    if session['guesses'] > guess:
        flash("Too Low")
    elif session['guesses'] < guess:
        flash("Too High")
    else:
        flash("You guessed the number! ")
        
    return redirect('/')


app.run(debug=True)