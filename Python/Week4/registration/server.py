from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re
import datetime
from flask_bcrypt import Bcrypt

app = Flask(__name__)
bcrypt = Bcrypt(app)
app.secret_key = "SecretKey"
mysql = MySQLConnector(app, 'mydb')

@app.route('/')
def index():
    query = mysql.query_db("SELECT * FROM users")
    # return "{}".format(query)
    return render_template('index.html', mydb=query)

@app.route('/new')
def new():
    return render_template('new.html')

#Where all the information from /new goes into
@app.route('/create_user', methods=['POST'])
def create_user():
    # checks to see if email is valid
    EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')

    # Calls all the information from the create page
    email = request.form['email']
    firstname = request.form['first_name']
    lastname = request.form['last_name']
    pw = request.form['pw']
    pw2 = request.form['pw2']

    # Checks to see if information that has been inputed is within the valid parameters
    #   First Name - letters only, at least 2 characters and that it was submitted
    if not firstname.isalpha():
        flash(u'First name is not valid, letters only')
        return redirect('/new')
    elif firstname<2:
        flash(u'First name is not valid, more than 2 characters')
        return redirect('/new')
    #   Last Name - letters only, at least 2 characters and that it was submitted
    elif not lastname.isalpha():
        flash(u'Last name is not valid, letters only')
        return redirect('/new')
    elif lastname<2:
        flash(u'Last name is not valid, more than 2 characters')
        return redirect('/new')
    # Email - Valid Email format, and that it was submitted
    elif not EMAIL_REGEX.match(email):
        flash(u'Email is not valid')
        return redirect('/new')
    # Password - at least 8 characters, and that it was submitted
    elif pw<8:
        flash(u'Password is not valid')
        return redirect('/new')
    # Password Confirmation - matches password
    elif pw!=pw2:
        flash(u'Passwords do not match')
        return redirect('/new')

    # Once everything has been checked, it will move onto the next portion to input information into db
    else:
        # run validations and if they are successful we can create the password hash with bcrypt
        pw_hash = bcrypt.generate_password_hash(pw)
        # now we insert the new user into the database
        insert_query = "INSERT INTO users (first_name, last_name, email, pw_hash, created_at)\
            VALUES (:firstname, :lastname, :email, :pw_hash, NOW())"
        query_data={
            "firstname":firstname,
            "lastname":lastname,
            "email":email,
            "pw_hash":pw_hash,
            "now": datetime.datetime.now()
        }
        mysql.query_db(insert_query, query_data)
        # redirect to success page
        return redirect('/')
# login Page
@app.route('/login')
def login():
    return render_template('login.html')

@app.route('/logincheck', methods=['POST'])
def logincheck():
    email = request.form['email']
    pw = request.form['pw']
    user_query = "SELECT * FROM users WHERE email = :email LIMIT 1"
    query_data = {'email':email}
    user = mysql.query_db(user_query, query_data)
    if bcrypt.check_password_hash(user[0]['pw_hash'], pw):
        print("User is logged in")
        return redirect('/')
    else:
        flash(u'Incorrect Password, please try again')
        return redirect('/login')

app.run(debug=True)