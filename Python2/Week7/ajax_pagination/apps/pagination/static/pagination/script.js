$().ready(function(){
    fetchLeads();
});

function fetchLeads(){
    $.ajax({
        url: '/fetch',
        method: 'get',
        success: function(res){
            let page_data = build_page(res);
            $("#leads").replaceWith(page_data.leads);
            $("#pages").replaceWith(page_data.pages);
        }
    });
}

function filterLeads(page = 1)
{
    $.ajaxSetup({
        beforeSend: function(xhr, settings) {
            if (!csrfSafeMethod(settings.type) && !this.crossDomain) {
                xhr.setRequestHeader("X-CSRFToken", window.CSRF_TOKEN);
            }
        }
    });
    $.ajax({
        url: '/filter',
        method: 'post',
        data: fetchFilterData(page),
        success: function(res){
            let page_data = build_page(res);
            $("#leads").replaceWith(page_data.leads);
            $("#pages").replaceWith(page_data.pages);
        }
    })
}

function fetchFilterData(page_num = 1)
{
    var searches = $(".search-field");
    return {
        name: searches[0].value,
        from: searches[1].value,
        to: searches[2].value,
        page: page_num
    }
}

$(document).on( "click", ".page-link", function(e){
    var page = ($(this).attr("data-page"));
    filterLeads(page);
});

$("#name-search").keyup(function(e){
    filterLeads();
});

$("#from-search").change(function(e){
    filterLeads();
});

$("#to-search").change(function(e){
    filterLeads();
});

function build_page(data)
{
    return {
        leads: build_leads(JSON.parse(data.object_list)),
        pages: build_links(data.pages)
    }

}
function build_links(pages){
    let links = document.createElement("nav"); 
    links.setAttribute("id", "pages");    
    for(let page in pages){
        let link = document.createElement("a");
        let page_val = parseInt(page) + 1;
        link.setAttribute("class", "page-link");
        link.innerText = page_val;
        link.setAttribute("href", "#");
        link.setAttribute("data-page", page_val);
        links.appendChild(link);
    }
    return links;
}
function build_leads(leads){
    let el = document.createElement('tbody');
    el.setAttribute("id", "leads");
    for(let i=0; i<leads.length; i++){
        let l_tr = document.createElement("tr")

        let l_id = document.createElement("td");
        l_id.innerText = leads[i].pk;
        l_tr.appendChild(l_id);

        let l_first = document.createElement("td");
        l_first.innerText = leads[i].fields.first_name;
        l_tr.appendChild(l_first);

        let l_last = document.createElement("td");
        l_last.innerText = leads[i].fields.last_name;
        l_tr.appendChild(l_last);
        
        let l_date = document.createElement("td");
        l_date.innerText = leads[i].fields.registered_datetime;
        l_tr.appendChild(l_date)

        let l_email = document.createElement("td");
        l_email.innerText = leads[i].fields.email;
        l_tr.appendChild(l_email);


        el.appendChild(l_tr);
    }
    return el;
}

// from django docs
function csrfSafeMethod(method) {
    // these HTTP methods do not require CSRF protection
    return (/^(GET|HEAD|OPTIONS|TRACE)$/.test(method));
}