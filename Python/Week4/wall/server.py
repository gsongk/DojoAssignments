from flask import Flask, flash, redirect, render_template, request, session
from flask_bcrypt import Bcrypt
from datetime import datetime
import re
from mysqlconnection import MySQLConnector

app = Flask(__name__)
bcrypt = Bcrypt(app)
app.secret_key = "SecretKey"
mysql = MySQLConnector(app, 'wall')

@app.route('/')
def index():
    return render_template('login.html')

@app.route('/logincheck', methods=['POST'])
def logincheck():
    email = request.form['email']
    pw = request.form['pw']
    user_query = "SELECT * FROM users WHERE email = :email LIMIT 1"
    query_data = {'email':email}
    user = mysql.query_db(user_query, query_data)

    if not user:
        flash(u'Email is not valid')
        return redirect('/')
    elif bcrypt.check_password_hash(user[0]['pw_hash'], pw):
        print("User is logged in")
        session['user_id'] = user[0]['id']
        return redirect('/wall')
    else:
        flash(u'Incorrect Password, please try again')
        return redirect('/')

@app.route('/logout')
def logout():
    session.pop('user_id', None)
    return redirect('/')

@app.route('/show')
def supreme_ruler():
    query = mysql.query_db("SELECT * From users")
    return render_template('show.html', wall=query)

@app.route('/create')
def new():
    return render_template('create.html')

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
        return redirect('/create')
    elif firstname<2:
        flash(u'First name is not valid, more than 2 characters')
        return redirect('/create')
    #   Last Name - letters only, at least 2 characters and that it was submitted
    elif not lastname.isalpha():
        flash(u'Last name is not valid, letters only')
        return redirect('/create')
    elif lastname<2:
        flash(u'Last name is not valid, more than 2 characters')
        return redirect('/create')
    # Email - Valid Email format, and that it was submitted
    elif not EMAIL_REGEX.match(email):
        flash(u'Email is not valid')
        return redirect('/create')
    # Password - at least 8 characters, and that it was submitted
    elif pw<8:
        flash(u'Password is not valid')
        return redirect('/create')
    # Password Confirmation - matches password
    elif pw!=pw2:
        flash(u'Passwords do not match')
        return redirect('/create')
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

# all the messages and comments are being displayed on the wall
@app.route('/wall')
def wall():
    session['user_id'] = 1
    # If there is no user_id in session it redirects it to main login page
    # This Section deals with displaying name on wall.html
    if not 'user_id' in session:
        return redirect('/')
    user_id = session['user_id']
    user_query_data = {'id': user_id}
    user_query= "SELECT * FROM users WHERE id= :id"
    user = mysql.query_db(user_query, user_query_data)
    
    # This section is directed towards message board
    message_query = "SELECT messages.id AS message_id, user_id, message, messages.updated_at, first_name, last_name FROM messages JOIN users ON users.id = messages.user_id"
    messages = mysql.query_db(message_query)
    
    # This section is directed towards comment board
    comment_query="SELECT comments.id AS comment_id, message_id, user_id, comment, comments.updated_at AS comment_updated_at, first_name, last_name FROM comments JOIN users ON users.id = comments.user_id"
    comments = mysql.query_db(comment_query)
    return render_template('wall.html', user=user[0], messages=messages, comments=comments)
    # user[0] states that user is an array and pulling index 0 and displays it on wall

# This is where the messages are being placed on the db
@app.route('/messageupdate', methods=['POST'])
def message_update():
    # This is where the messages are being inputted
    user_id = session['user_id']
    message_data = {
        "new_user_id": user_id,
        "new_message": request.form['messagebox'],
        "now": datetime.now()
    }
    message_query = "INSERT INTO messages (user_id, message, created_at, updated_at)\
        VALUE(:new_user_id, :new_message, :now, :now)"
    mysql.query_db(message_query, message_data)
    return redirect('/wall')

# This is where the comments are being displayed
@app.route('/<message_id>/comment_update', methods=['POST'])
def comment_update(message_id):
    user_id = session['user_id']
    comment_data = {
        "new_user_id": user_id,
        "new_message_id": message_id,
        "new_comment": request.form['commentbox'],
        "now": datetime.now()
    }
    comment_query = "INSERT INTO comments (message_id, user_id, comment, created_at, updated_at)\
         VALUE(:new_message_id, :new_user_id, :new_comment, :now, :now)"
    mysql.query_db(comment_query, comment_data)
    return redirect('/wall')


@app.route('/<message_id>/delete_message', methods=['POST'])
def delete_message(message_id):
    data = {"message_id": message_id}
    date_message_query = "SELECT created_at FROM messages WHERE id=:message_id"
    date_message = mysql.query_db(date_message_query, data)
    date_of_message = date_message[0]['created_at']
    time = datetime.now() - date_of_message
    minutes_left = time.days * 24 * 60
    print ('time:', minutes_left)
    
    if minutes_left < 30:
        message_query = "DELETE FROM messages WHERE id=:message_id"
        comment_query = "DELETE FROM comments WHERE message_id=:message_id"
        mysql.query_db(comment_query, data)
        mysql.query_db(message_query, data)
    else:
        flash(u'Message is more than 30 minutes old, cannot delete')
        return redirect('/wall')
    return redirect ('/wall')

app.run(debug=True)
