
detailPost();

function detailPost() {
    const urlParams = new URLSearchParams(window.location.search);
    const postId = urlParams.get('id');
    axios.get(`/api/ClientApi/${postId}`)
        .then((res) => {
            /*console.log(res);*/
            const post = res.data;
            let descriptionHTML = '';
            /* Description Control(null) */
            if (post.description != null) {
                descriptionHTML = `<span class="shadow p-3 rounded"><span class="fw-bold">Description: </span>${post.description}</span>`
            }

            document.getElementById('y-img').innerHTML =
                `   
                    <!--Image-->
                    <div class="card_image rounded">
                        <img class="my_img rounded" src="${post.img}" alt="Error: ${post.title}">
                    </div>

                    <span class="text-light rounded fw-bold bg-dark px-3 py-2">${post.title}</span>

                `;
            document.getElementById('y-corp').innerHTML =
                `   
                
                    ${descriptionHTML}

                `;
            

            document.getElementById('y-category').innerHTML = '';
            res.data.category.forEach(category => {
                document.getElementById('y-category').innerHTML += 
                `
                    <li class="badge bg-info">
                        ${category.name}
                    </li>    

                `
            })
        })
        .catch((res) => {
            console.log('bad NOT', res)
        })
}