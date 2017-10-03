from flask import Flask, render_template, request, redirect
app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/ninja/<color>')
def show(color):
    ninjas = {
        'orange':'michelangelo',
        'blue':'leonardo',
        'red':'raphael',
        'purple':'donatello'
    }

    if color in ninjas:
        character = ninjas[color]
    else:
        character = 'notapril'
    return render_template('show.html', character = character)

app.run(debug=True)