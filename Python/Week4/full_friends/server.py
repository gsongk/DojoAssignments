from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re
import datetime

app = Flask(__name__)
app.secret_key = "SecretKey"
mysql = MySQLConnector(app,'fullfriends')


@app.route('/')
def index():
    query = mysql.query_db("SELECT * FROM friends")
    # return "{}".format(query)
    return render_template('index.html', fullfriends=query)

@app.route('/friends', methods=['POST'])
def create():
    EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
    email = request.form['email']
    if not EMAIL_REGEX.match(email):
        flash(u'Email is not valid')
    else:
        data = {
            "new_firstname": request.form['first_name'],
            "new_lastname": request.form['last_name'],
            "new_email": email,
            "now": datetime.datetime.now()
        }
        query="INSERT INTO friends (first_name, last_name, email, created_at, updated_at)\
            VALUES(:new_firstname, :new_lastname, :new_email, :now, :now)"
        mysql.query_db(query, data)
    return redirect('/')

@app.route('/friends/<id>/edit', methods=['GET'])
def edit(id):
    # Useed to test the link
    # query = mysql.query_db("SELECT * FROM friends")
    # return"{}".format(query)
    try:
        query = mysql.query_db("SELECT * FROM friends WHERE id={}".format(id))[0]
    except:
        return redirect('/')
    return render_template('edit.html', fullfriends=query)

@app.route('/friends/<id>', methods=['POST'])
def update(id):
    EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
    email = request.form['email']
    if not EMAIL_REGEX.match(email):
        flash(u'Email is not valid')
    else:
        data = {
                "new_firstname": request.form['first_name'],
                "new_lastname": request.form['last_name'],
                "new_email": email,
                "id": id,
                "now": datetime.datetime.now()
            }
        query="UPDATE friends SET first_name=:new_firstname,\
             last_name=:new_lastname, email=:new_email, updated_at=:now WHERE id=:id"
        mysql.query_db(query, data)
    return redirect('/')

@app.route("/friends/<id>/delete", methods=['POST'])
def destroy(id):
    query = "DELETE FROM friends WHERE id=:id"
    data = {"id":id}
    mysql.query_db(query,data)
    return redirect('/')

app.run(debug=True)