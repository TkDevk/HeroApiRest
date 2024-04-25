import { useState } from "react";
import axios from "axios";

const Boton = () => {
  const [hero, setHero] = useState([]);
  const handleClick = () => {
    axios
      .get("https://localhost:7012/api/hero")
      .then((response) => {
        console.log(response.data);
        setHero(response.data);
      })
      .catch((err) => {
        console.log(err);
      });
  };
  const getHero = hero
    .filter((h) => h.heroName)
    .map((hero) => {
      return (
      <li key={hero.id}>{hero.heroName}</li>);
    });
  return (
    <>
      <button onClick={handleClick}>Click!</button>
      <ul>{getHero}</ul>
    </>
  );
};
export default Boton;
