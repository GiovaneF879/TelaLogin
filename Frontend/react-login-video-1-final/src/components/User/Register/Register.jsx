import React, { useState, useContext } from 'react';
import { useHistory } from 'react-router-dom';
import StoreContext from 'components/Store/Context';
import UIButton from 'components/UI/Button/Button';
import logo from './logot.png';
import './Registerr.css';
import RegisterService from 'pages/Register/Service';

const service = new RegisterService();

function initialState() {
  return { email: '', password: '' };
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

  async function register() {
    const { status, data } = await service.register(values.email, values.password);
    if (status === 200) {
      return { token: data.token };
    }
    return { error: 'Ocorreu um problema, contate o suporte' }
  }

  async function onSubmit(event) {
    event.preventDefault();

    const { token, error } = await register();

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
      <div className="textRegister">CADASTRO</div>
      <form onSubmit={onSubmit}>
        <div className="user-login__form-control">
          <label htmlFor="email"></label>
          <input
            id="email"
            type="text"
            name="email"
            onChange={onChange}
            value={values.email}
            placeholder="E-mail"
            required
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
            placeholder="Senha"
            required
          />
          <p className="labelCaracteres">Mínimo de 6 caracteres</p>
        </div>
        <UIButton
          type="submit"
          theme="contained-green"
          className="user-login__submit-button"
          rounded
        >
          Entrar
        </UIButton>
        <div className="containerComeBack">
          <a className="comeBack" onClick={() => history.push('/login')}>Voltar</a>
        </div>
        {error && (
          <div className="user-login__error">{error}</div>
        )}
      </form>
    </div>
  );
};

export default Register;
