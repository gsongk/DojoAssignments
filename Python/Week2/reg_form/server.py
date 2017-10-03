# All fields are required and must not be blank - Done
# First and Last Name cannot contain any numbers - Done
# Password should be more than 8 characters - Done
# Email should be a valid email
# Password and Password Confirmation should match - Done

from flask import Flask, render_template, request, redirect, session, flash
import re
from datetime import datetime

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
DATE_REGEX = re.compile(r'^\d{1,2}\/\d{1,2}\/\d{4}$')
PASSWORD_REGEX = re.compile(r'^(?=.*?[A-Z])(?=.*?[0-9])')
app = Flask(__name__)
app.secret_key = "SecretKey"


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/process', methods=['POST'])
def process():
    errors = False
# Email portion of the assignment
    if len(request.form['email']) == 0:
        flash('Email is not valid', 'error')
        errors = True

# First name portion 
    if len(request.form['fname']) == 0:
        flash('First Name cannot be blank!', 'error')
        errors = True
    elif not request.form['fname'].isalpha():
        flash('First name cannot contain any numbers or special characters', 'error')
        errors = True

# Last Name portion
    if len(request.form['lname']) == 0:
        flash('Last Name cannot be blank!', 'error')
        errors = True
    elif not request.form['lname'].isalpha():
        flash('Last name cannot contain any numbers or special characters', 'error')
        errors = True

# Password portion
    if len(request.form['password']) < 8:
        flash('Password must be at least 8 characters long', 'error')
        errors = True
    elif not PASSWORD_REGEX.match(request.form['password']):
        flash('Password must contain at least one upper case letter and one number', 'error')
        errors = True
    elif (request.form['password']) != (request.form['confirm']):
        flash('Password and Confirmation of Password does not match', 'error')
        errors = True
    if not errors:
        flash('Successful Registration', 'sucess')
    return redirect('/')

# Birthdate portion
    if len(request.form['date']) == 0:
        flash('Not valid Birthdate', 'error')
        errors = True
    elif not DATE_REGEX.match(request.form['date']):
        flash('Date does not follow format (MM/DD/YY)', 'error')
        errors = True
    else:
        try:
            checkDate = datetime.strptime(request.form['date'], '%m/%d/%y')
            if checkDate > datetime.today():
                flash('Incorrect', 'error')
                errors = True
        except ValueError:
            flash('Incorrect', 'error')
            errors = True

#Clears session and returns them back to main page index.html
@app.route('/reset')
def clear():
    session.clear()
    return redirect('/')

app.run(debug=True)