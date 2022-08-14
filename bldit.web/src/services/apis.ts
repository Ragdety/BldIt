import axios from 'axios';

const bldItApiBaseURL: string = process.env.REACT_APP_BLDIT_BASE_API_URL_SECURE!;

export default axios.create({
    baseURL: bldItApiBaseURL,
    headers: {
        "Content-type": "application/json"
    }
});