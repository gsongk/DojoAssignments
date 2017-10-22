from flask import Flask, request, redirect, render_template, session, flash
import re
from mysqlconnection import MySQLConnector
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')
app = Flask(__name__)
app.secret_key = 'ThisIsSecret'
mysql = MySQLConnector(app,'email_validationdb')
@app.route('/')
def index():
    return render_template('index.html')


@app.route('/email', methods=['POST'])
def email():
    form_complete = True
    #checks that the form is filled and is a valid email
    if len(request.form['email']) < 1:
        flash("Email cannot be blank")
        form_complete = False
    elif not EMAIL_REGEX.match(request.form['email']):
        flash("Email not valid")
        form_complete = False

    if form_complete:
        #adds email to data base and loads the success page
        query = "INSERT INTO email (email, created_at) VALUES (:email, NOW())"
        data = {
                 'email': request.form['email']
               }
        mysql.query_db(query, data)
        flash(request.form['email'])
        return redirect('/success')
    else:
        return redirect('/')

@app.route('/success')
def success():
    emails = mysql.query_db("SELECT * FROM email")
    return render_template('success.html', emails=emails)

# @app.route('/delete/<int:email_id>', methods=['DELETE'])
# def delete(email_id):
#     if not session.get('logged_in'):
#         abort(401)
#     g.db.execute('DELETE FROM email WHERE id = ?', [email_id])
#     flash ('Entry was deleted')
#     return redirect(url_for('show_entries'))

app.run(debug=True)