import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'banco',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44395/',
    redirectUri: baseUrl,
    clientId: 'banco_App',
    responseType: 'code',
    scope: 'offline_access banco',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44395',
      rootNamespace: 'banco',
    },
  },
} as Environment;
