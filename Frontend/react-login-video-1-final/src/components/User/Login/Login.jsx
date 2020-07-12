import React, { useState, useContext } from 'react';
import { useHistory } from 'react-router-dom';
import StoreContext from 'components/Store/Context';
import UIButton from 'components/UI/Button/Button';
import logo from './logot.png';
import './Login.css';
import LoginService from 'pages/Login/Service';

const service = new LoginService();

function initialState() {
  return { user: '', password: '' };
}

async function login({ user, password }) {
  const { status, data } = await service.login(user, password);
  if (status === 200) {
    return { token: data.token };
  }
  return { error: 'Usuário ou senha inválido' }
}

async function recuperarSenha(email) {
  console.log(email, "Email");
  const { status, data } = await service.recuperarSenha(email);
  if (status === 200) {
    return { token: data.token };
  }
  return { error: 'Erro ao recuperar senha, contate o suporte' }
}

const UserLogin = () => {
  const [values, setValues] = useState(initialState);
  const [error, setError] = useState(null);
  const { setToken } = useContext(StoreContext);
  const history = useHistory();

  function onChange(event) {

    const { value, name } = event.target;

    setValues({
      ...values,
      [name]: value
    });
  }

  async function onSubmit(event) {
    event.preventDefault();

    const { token, error } = await login(values);

    if (token) {
      setToken(token);
      return history.push('/');
    }

    setError(error);
    setValues(initialState);
  }

  return (
    <div className="user-login">
      <img src={logo} className="logo" alt="logo" />
      <form onSubmit={onSubmit}>
        <div className="user-login__form-control">
          <label htmlFor="user"></label>
          <input
            id="user"
            type="text"
            name="user"
            onChange={onChange}
            value={values.user}
            placeholder=" Usuário "
          />
        </div>
        <div className="user-login__form-control">
          <label htmlFor="password"></label>
          <input
            id="password"
            type="password"
            name="password"
            onChange={onChange}
            value={values.password}
            placeholder=" Senha "
          />
        </div>
        <UIButton
          type="submit"
          theme="contained-green"
          className="user-login__submit-button"
          rounded
        >
          Entrar
        </UIButton>
        <div className="containerRegister">
          <a className="alterPassword" onClick={() => history.push('/recuperar-senha')}>Esqueci minha senha</a>
          <p className="separator">|</p>
          <a className="registerLink" onClick={() => history.push('/registrar')}>Registre-se</a>
        </div>
        {error && (
          <div className="user-login__error">{error}</div>
        )}
      </form>
    </div>
  );
};

export default UserLogin;
