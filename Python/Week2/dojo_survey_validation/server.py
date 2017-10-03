from flask import Flask, render_template, request, redirect, session, flash
app = Flask(__name__)
# our index route will handle rendering our form
app.secret_key = "SecretKey"

@app.route('/')

def index():
    return render_template('index.html')
# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route

@app.route('/users', methods=['GET', 'POST'])

def create():
    errors = False

    if len(request.form['name']) < 1:
        flash('Name cannot be empty!')
        errors = True
    if len(request.form['comment']) <1:
        flash("Comment Empty!")
        errors = True
    elif len(request.form['comment']) > 120:
        flash('Only 120 characters long')
        errors = True
    
    if errors ==True:
        return redirect('/')

    else:
        print 'Got Post Info'
        session['name'] = request.form['name']
        session['location'] = request.form['location']
        session['language'] = request.form['language']
        session['comment'] = request.form['comment']
        # redirects back to the '/' route
    return redirect('/show')

@app.route('/show')
def show():
    return render_template('users.html')

@app.route('/reset')
def clear():
    session.clear()
    return redirect ('/')

app.run(debug=True)# run our server