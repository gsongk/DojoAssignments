from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
# our index route will handle rendering our form
app.secret_key = "SecretKey"

# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route

@app.route('/')
def index():
    session['counter'] += 1
    return render_template('index.html')

@app.route('/ninjas', methods=['POST'])
def add_two():
    session['counter'] += 2
    return redirect('/')

@app.route('/hackers', methods=['POST'])
def reset():
    session['counter'] = 0
    return redirect('/')

app.run(debug=True)# run our server

#person goes on to site, counter moves up one
#clicking a button ninja or hacker
#causes counter to move up 1 or 2