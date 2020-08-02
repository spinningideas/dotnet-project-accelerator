import HttpClient from 'services/HttpClient';

const DNPAServices = () => {
  const baseUrl = 'http://localhost:5001';
  const getContinents = async () => {
    const client = HttpClient();
    let url = baseUrl + `/continents`;
    return await client.getData(url).then((response) => {
      return response.data;
    });
  };

  const getCountries = async (continentCode) => {
    const client = HttpClient();
    let url = baseUrl + `/countries/` + continentCode;
    return await client.getData(url).then((response) => {
      return response.data;
    });
  };

  const searchCountries = async (searchTerm) => {
    const client = HttpClient();
    let url = baseUrl + `/countries/search/`;
    return await client.postData(url, { searchTerm: searchTerm }).then((response) => {
      return response.data;
    });
  };

  return {
    getContinents,
    getCountries,
    searchCountries
  };
};

export default DNPAServices;
