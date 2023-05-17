loadPosts();

function loadPosts(searchKey) {
    axios.get('/api/ClientApi', {
        params: {
            search: searchKey
        }
    })
        .then((res) => {
            console.log('richiesta OK', res)
            if (res.data.length == 0) {
                document.getElementById('y-posts').classList.add('d-none');
                document.getElementById('no-posts').classList.remove('d-none')
            } else {
                document.getElementById('y-posts').classList.remove('d-none');
                document.getElementById('no-posts').classList.add('d-none')

                document.getElementById('y-posts').innerHTML = '';
                res.data.forEach(post => {
                    console.log('Post', post);
                    let descriptionHTML = '';
                    /* Description Control(null) */
                    if (post.description != null) {
                        descriptionHTML = `<span><span class="fw-bold">Description: </span>${post.description}</span>`
                    }
                    document.getElementById('y-posts').innerHTML += 
                    `
                        <li class="d-flex gap-3">
                        
                            <!--Image-->
                            <div class="card_image rounded">
                                <img class="my_img rounded" src="${post.img}" alt="Error: ${post.title}">
                            </div>
                        

                            <div class="d-flex flex-column align-items-center justify-content-around gap-3 w-100 border border-1 border-warning rounded shadow">
                            
                                <div class="d-flex flex-column">
                                    <span><span class="fw-bold">Title: </span>${post.title}</span>
                                    ${descriptionHTML}
                                </div>

                                <div class="d-flex gap-3">
                                    <!--Details-->
                                    <a class="btn btn-dark shadow rounded-pill py-2 px-3" href="Client/Details?id=${post.id}">
                                        <i class="fa-regular fa-eye"></i>
                                    </a>
                                </div>

                            </div>

                        </li>
                    `
                })
            }
        })
        .catch((res) => {
            console.log('bad NOT', res)
        })
}
