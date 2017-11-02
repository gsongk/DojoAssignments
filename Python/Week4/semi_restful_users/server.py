from flask import Flask, request, redirect, render_template, session
from mysqlconnection import MySQLConnector
import datetime

app = Flask(__name__)
app.secret_key = "SecretKey"
mysql = MySQLConnector(app, 'mydb')

@app.route('/')
def index():
    query = mysql.query_db("SELECT id, CONCAT_WS(' ', first_name, last_name) AS full_name, email, created_at, updated_at FROM users")
    # return "{}".format(query)
    return render_template('index.html', users = query)


@app.route('/users/<id>')
def show(id):
    try:
        query = mysql.query_db("SELECT id, CONCAT_WS(' ', first_name, last_name) AS full_name, email, created_at, updated_at FROM users WHERE id={}".format(id))[0]
    except:
        return redirect('/')
    return render_template('show.html', user = query)

@app.route('/users/new')
def new():
    return render_template('new.html')


@app.route("/users/create", methods=['POST'])
def create():
    data = {
        "new_first_name": request.form['first_name'],
        "new_last_name": request.form['last_name'],
        "new_email": request.form['email'],
        "now": datetime.datetime.now()
    }
    query = "INSERT INTO users (first_name, last_name, email, created_at, updated_at)\
        VALUES (:new_first_name, :new_last_name, :new_email, :now, :now)"
    mysql.query_db(query, data)
    return redirect('/')

@app.route("/users/<id>/edit" )
def edit(id):
    try:
        query = mysql.query_db("SELECT * FROM users WHERE id={}".format(id))[0]
    except:
        return redirect('/')
    return render_template('edit.html', user = query)


@app.route("/users/<id>/update", methods=['POST'])
def update(id):
    data = {
        "id":id,
        "updated_first_name": request.form['first_name'],
        "updated_last_name": request.form['last_name'],
        "updated_email": request.form['email'],
        "now": datetime.datetime.now()
    }
    query = "UPDATE users SET first_name=:updated_first_name, last_name=:updated_last_name, email=:updated_email, updated_at=:now WHERE id=:id"
    mysql.query_db(query, data)
    return redirect('/users/<id>')


@app.route("/users/<id>/delete")
def delete(id):
    query = "DELETE FROM users WHERE id=:id"
    data = {"id": id}
    mysql.query_db(query, data)
    return redirect('/')

app.run(debug=True)
