export const APPBASEPATH = 'dotnet-project-accelerator';

export const reloadWindow = () => {
  window.location = window.location.origin
    ? window.location.origin + '/' + APPBASEPATH
    : window.location.protocol + '/' + window.location.host + '/' + APPBASEPATH;
};
