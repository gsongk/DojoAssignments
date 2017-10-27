from flask import Flask, request, redirect, render_template
from mysqlconnection import MySQLConnector
import datetime

app = Flask(__name__)
mysql = MySQLConnector(app,'mydb')

@app.route('/')
def index():
    query = mysql.query_db("SELECT * FROM friends")
    #return "{}".format(query) 
    return render_template('index.html', friends=query)

@app.route('/<friend_id>')
def show(friend_id):
    try:
        query = mysql.query_db("SELECT * FROM friends WHERE id={}".format(friend_id))[0]
    except:
        return redirect('/')
    return render_template('show.html', friends=query)

@app.route('/new')
def new():
    return render_template('new.html')

@app.route("/create", methods=['POST'])
def create():
    data = {
        "new_username": request.form['friend'],
        "now": datetime.datetime.now()
    }
    query="INSERT INTO friends (username, created_at, updated_at)\
        VALUES (:new_username, :now, :now)"
    mysql.query_db(query, data)
    return redirect('/')

@app.route('/<friend_id>/edit')
def edit(friend_id):
    try:
        query = mysql.query_db("SELECT * FROM friends WHERE id={}".format(friend_id))[0]
    except:
        return redirect('/')
    return render_template('edit.html', friends=query)

@app.route("/<friend_id>/update", methods=['POST'])
def update(friend_id):
    data = {
        "friend_id": friend_id,
        "updated_username": request.form['username'],
        "now": datetime.datetime.now()
    }
    query="UPDATE friends SET username=:updated_username, updated_at=:now WHERE id=:friend_id"
    mysql.query_db(query, data)
    return redirect('/')

@app.route("/<friend_id>/delete")
def delete(friend_id):
    query = "DELETE FROM friends WHERE id=:friend_id"
    data = {"friend_id": friend_id}
    mysql.query_db(query, data)
    return redirect('/')

app.run(debug=True)