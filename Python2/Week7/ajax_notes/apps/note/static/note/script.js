initialize();

$('#note-form').submit(function(e){
    e.preventDefault();
    let data_to_request = $(this).serialize();
    $.ajaxSetup({
        beforeSend: function(xhr, settings) {
            if (!csrfSafeMethod(settings.type) && !this.crossDomain) {
                xhr.setRequestHeader("X-CSRFToken", window.CSRF_TOKEN);
            }
        }
    });
    $.ajax({
        url: e.target.action,
        method: 'post',
        data: data_to_request,
        success: function(response){
            $('#notes').html(renderNotes(response));
        }
    });
    $(this)[0].reset();
})

$('#notes').on('submit', '.update-note-form', function(e){
    e.preventDefault();
    let data_to_request = $(this).serialize();

    // from django docs - we must pack the request with a csrftoken.
    $.ajaxSetup({
        beforeSend: function(xhr, settings) {
            if (!csrfSafeMethod(settings.type) && !this.crossDomain) {
                xhr.setRequestHeader("X-CSRFToken", window.CSRF_TOKEN);
            }
        }
    });

    $.ajax({
        url: e.target.action,
        method: 'post',
        data: data_to_request,
        success: function(response){
            $('#notes').html(renderNotes(response));
        }
    });
    $(this)[0].reset();
})

$('#notes').on("click", ".note>p", function(){
    let note_obj = {
        content: $(this).text(),
        id: $(this).siblings()[1].innerText 
    }
    $(this).replaceWith(buildEditNoteForm(note_obj));
})

function initialize(){
    $.ajax({
        url: '/initialize',
        method: 'get',
        success: function(response){
            $('#notes').html(renderNotes(response));
        }
    })
}

function renderNotes(notes){
    let el = document.createElement('div');
    el.setAttribute("class", "notes");
    for(let i=0;i<notes.length;i++){
        var note = document.createElement('div');
        note.setAttribute('class', 'note');
        
        // build delete button
        del_btn = document.createElement('button');
        del_btn.innerText = "X";
        del_btn.addEventListener("click", function(){
            $.ajax({
                url: '/delete/'+notes[i].pk,
                method: 'get',
                success: function(response){
                    $('#notes').html(renderNotes(response));
                }
            })
        })
        note.appendChild(del_btn);

        // build title h3
        title = document.createElement('h3');
        title.innerText = notes[i].fields.title;
        note.appendChild(title);

        // build content p
        content = document.createElement('p');
        content.innerText = notes[i].fields.content;
        note.appendChild(content);

        // build hidden span for id
        id_span = document.createElement('span')
        id_span.innerText = notes[i].pk;
        note.appendChild(id_span);
        el.appendChild(note);
    }
    return el;
}

function buildEditNoteForm(note_obj){
    let el = document.createElement("div");
    let update_form = document.createElement("form");
    update_form.setAttribute("class", "update-note-form");
    update_form.setAttribute("action", "/update/"+note_obj.id);
    update_form.setAttribute("method", "post");

    // build form-group div
    let form_group = document.createElement("div")
    form_group.setAttribute("class", "form-group")

    // build text area for note content
    let ta = document.createElement("textarea")
    ta.setAttribute("name", "content");
    ta.innerText = note_obj.content;
    form_group.appendChild(ta);

    // build submit input
    let submit = document.createElement('input');
    submit.setAttribute('type', 'submit');
    submit.setAttribute('value', 'Update');

    // build cancel button
    let cancel_btn = document.createElement('button');
    cancel_btn.innerText = "Cancel";
    cancel_btn.addEventListener("click", initialize)
    update_form.appendChild(form_group);
    update_form.appendChild(submit);

    el.appendChild(update_form);
    el.appendChild(cancel_btn);
    return el;
} 

function delete_note(note_id){
    $.ajax({
        url: '/delete/'+note_id,
        method: 'get',
        success: function(response){
            $('#notes').html(renderNotes(response));
        }
    })
}

// from django docs
function csrfSafeMethod(method) {
    // these HTTP methods do not require CSRF protection
    return (/^(GET|HEAD|OPTIONS|TRACE)$/.test(method));
}