const bases = {
    Identity: '/identity',
    Projects: '/projects'
}

const routes = {
    Login: bases.Identity + '/login',
    Register: bases.Identity + '/register',
    Projects: {
        getAll: bases.Projects,
    },
}

export default routes;