import apis from '../apis';


const getAll = () => {
    apis.bldItApi.get('/projects')
}


const ProjectsService = {
    getAll
};

export default ProjectsService;