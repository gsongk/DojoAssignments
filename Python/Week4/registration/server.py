from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re
import datetime
from flask_bcrypt import Bcrypt

app = Flask(__name__)
bcrypt = Bcrypt(app)
app.secret_key = "SecretKey"
mysql = MySQLConnector(app, 'mydb')

@app.route('/', methods=['GET'])
def index():
    # query = mysql.query_db("SELECT * FROM users")
    # return "{}".format(query)
    return render_template('index.html')

@app.route('/create_user', methods=['POST'])
def create_user():
    email = request.form['email']
    username = request.form['username']
    password = request.form['password']
    # run validations and if they are successful we can create the password hash with bcrypt
    pw_hash = bcrypt.generate_password_hash(password)
    # now we insert the new user into the database
    insert_query = "INSERT INTO users (email, username, pw_hash, created_at) VALUES (:email, :username, :pw_hash, NOW())"
    query_data = { 'email': email, 'username': username, 'pw_hash': pw_hash }
    mysql.query_db(insert_query, query_data)
    # redirect to success page
    return redirect('/success')


app.run(debug=True)