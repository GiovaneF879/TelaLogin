import api from '../../Service/api';


export default class RegisterService {
    register = async (user, password, name, email) => {
        let data = {
            "userName": user,
            "password": password,
            "name": name,
            "email": email
        }
        const resultApi = await api.post("/v1/user", data)
        return resultApi;
    }
}