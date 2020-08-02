import React, { Fragment } from 'react';
import { Link } from 'react-router-dom';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import Divider from '@material-ui/core/Divider';
import LoadingIndicator from 'components/Shared/LoadingIndicator';

const ContinentsList = (props) => {
  if (!props.dataIsLoading && props.continentsData.length > 0) {
    return props.continentsData.map((continent, index) => (
      <Fragment key={index}>
        <ListItem button button key={index} component={Link} to={`/countries/${continent.continentCode}`}>
          <ListItemText primary={continent.continentName}></ListItemText>
        </ListItem>
        <Divider component="li" />
      </Fragment>
    ));
  } else {
    return <LoadingIndicator display={props.isLoadingState} size={20} />;
  }
};

export default ContinentsList;
