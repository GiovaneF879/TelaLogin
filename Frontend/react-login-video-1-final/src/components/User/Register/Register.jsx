import React, { useState, useContext } from 'react';
import { useHistory } from 'react-router-dom';
import StoreContext from 'components/Store/Context';
import UIButton from 'components/UI/Button/Button';
import logo from './logot.png';
import './Registerr.css';
import RegisterService from 'pages/Register/Service';

const service = new RegisterService();

function initialState() {
  return { user: '', password: '', name: '', email: '' };
}


const Register = () => {
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

  async function register({ user, password, name, email }) {
    const { status, data } = await service.register(user, password, name, email);
    if (status === 200) {
      return { token: data.token };
    }
    return { error: 'Ocorreu um problema, contate o suporte' }
  }

  async function onSubmit(event) {
    event.preventDefault();

    const { token, error } = await register(values);

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
          <label htmlFor="name"></label>
          <input
            id="name"
            type="text"
            name="name"
            onChange={onChange}
            value={values.name}
            placeholder="Nome Completo"
          />
        </div>
        <div className="user-login__form-control">
          <label htmlFor="email"></label>
          <input
            id="email"
            type="text"
            name="email"
            onChange={onChange}
            value={values.email}
            placeholder="E-mail"
          />
        </div>
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
        {error && (
          <div className="user-login__error">{error}</div>
        )}
        <UIButton
          type="submit"
          theme="contained-green"
          className="user-login__submit-button"
          rounded
        >
          Entrar
        </UIButton>
        <a onClick={() => history.push('/login')}>Voltar</a>
      </form>
    </div>
  );
};

export default Register;
