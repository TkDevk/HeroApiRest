import axios from "axios";
const BASEURL = "https://localhost:7012/api/hero";
import { useState } from "react";

const EditInputTextHero = () => {
  const[inputData, setInputData] = useState([]);
  const handleClick = async() =>{
   await axios
    .get(BASEURL)
    .then((response) => {
        console.log(response.data)
        setInputData(response.data)
    })
    .catch((err) => console.error(err));
  }
  
  const heroOptions = inputData.filter(hero => hero.NameHero).map(hero => (
    <option key={hero.NameHero} value={hero.NameHero}>{hero.NameHero}</option>
  ));

  return (
    <>

      <button onClick={handleClick}>Put</button>
      <label>Choose a car:</label>
      <select name={heroOptions} id={heroOptions}>
        {heroOptions}
      </select>
    </>
  );
};
export default EditInputTextHero;
