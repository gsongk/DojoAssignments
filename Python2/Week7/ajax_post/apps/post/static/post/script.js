$('form').submit(function (e) {
    e.preventDefault();
    console.log($(this).serialize());
    $.ajax({
        url: e.target.action,
        method: 'post',
        data: $(this).serialize(),
        success: function (response) {
            console.log(response)
            $('#notes').html(renderNotes(response))
        }
    })
    $(this)[0].reset();
})
$().ready(function () {
    $.ajax({
        url: '/initialize',
        method: 'get',
        success: function (response) {
            $('#notes').html(renderNotes(response))
        }
    })
})
function renderNotes(notes) {
    var el = document.createElement('div');
    for (post in notes) {
        var n = document.createElement('div');
        n.setAttribute('class', 'note');
        t = document.createElement('h2');
        t.innerText = notes[post].fields.content;
        n.appendChild(t);
        el.appendChild(n);
    }
    return el
}