import axios from 'axios';

const bldItApiBaseURL: string = process.env.REACT_APP_BLDIT_BASE_API_URL_SECURE!;

const bldItApi = axios.create({
    baseURL: bldItApiBaseURL,
    headers: {
        'Accept': 'application/json',
        "Content-type": "application/json"
    }
});

//TODO: Look at this later
// bldItApi.interceptors.response.use(
//     (response) =>  {
//         return response;
//     },
//     (error) => {
//         const res = error.response;
//         if (res.status == 401) {
//             window.location.href = '';
//         }
//         console.error(`Looks like there was a problem. Status Code: ${res.status}`);
//         return Promise.reject(error);
//     }
// );

export default {
    bldItApi
}