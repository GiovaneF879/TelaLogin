import api from '../../Service/api';


export default class RegisterService {
    register = async (email, password) => {
        let data = {
            "email": email,
            "password": password
        }
        const resultApi = await api.post("/v1/user", data)
        return resultApi;
    }
}