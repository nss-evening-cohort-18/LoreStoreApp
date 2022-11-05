import firebase from 'firebase/app';
import 'firebase/auth';
import UserApi from '../api/userApi';

const signIn = async () => {
  const provider = new firebase.auth.GoogleAuthProvider();
  const userLogin = await firebase.auth().signInWithPopup(provider);
  UserApi.UserExists(userLogin.user.uid, userLogin.user.Aa);
};

const signOut = () => {
  firebase.auth().signOut();
};

export { signIn, signOut };
