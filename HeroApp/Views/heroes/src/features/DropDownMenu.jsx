import axios from "axios";
import { useEffect, useState } from "react";
import ModifyHero from "./components/ModifyHero";
const BASEURL = "https://localhost:7012/api/hero";
const DropDownMenu = () => {
  
  const [isIdSelected, setIsIdSelected] = useState(0);
  const [heroData, setHeroData] = useState([]);
  const getHeroes = async () => {
    await axios
      .get(BASEURL)
      .then((res) => {
        setHeroData(res.data);
      })
      .catch((err) => console.log(err));
  };
  useEffect(() => {
    getHeroes();
  }, []);

  const OnSelected = (e)=>{
    setIsIdSelected(e.target.options[e.target.selectedIndex].value);
    console.log( e.target.options[e.target.selectedIndex].value);
  }
  const dropMenu = heroData.map(h=>{
    return (
        <option key={h.id} value={h.id}>{h.name}, Hero name: {h.heroName}</option>
    )
  })
  return (
    <>
      <select name="Heroes" 
      onChange={OnSelected}>
      <option value={"choseHero"}> Heroes </option>  
        {dropMenu}
      </select>
      <ModifyHero heroId={isIdSelected}/>
    </>
  );
};
export default DropDownMenu;
