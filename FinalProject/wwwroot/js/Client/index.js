loadPosts();

function loadPosts() {
    axios.get('/api/ClientApi')
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
                    document.getElementById('y-posts').innerHTML += 
                    `
                        <li class="d-flex gap-3">
                        <div>
                            <!--Image-->
                            <div class="card_image rounded">
                                <img class="rounded" src="${post.img}" alt="Error: ${post.title}">
                            </div>
                        </div>

                        <div class="d-flex flex-column align-items-center justify-content-around gap-3 w-100 border border-1 border-warning">

                            <div class="d-flex flex-column">
                                <span><span class="fw-bold">Title: </span>${post.title}</span>
                                <span><span class="fw-bold">Description: </span>${post.description}</span>
                            </div>

                            <div class="d-flex gap-3">
                                <!--Details-->
                                <a class="btn btn-dark shadow rounded-pill py-2 px-3" href="/Client/Detail?id=${post.id}">
                                    <i class="fa-regular fa-eye"></i>
                                </a>
                            </div>
                    `
                })
            }
        })
        .catch((res) => {
            console.log('bad NOT', res)
        })
}

function detailPost(postId) {

}